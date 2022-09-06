import Detail from './detail';
import axios from 'axios';
import React, { useState, useEffect } from 'react';
import Moment from 'moment';
import DateRangePicker from 'react-bootstrap-daterangepicker';
import { useNavigate } from 'react-router-dom';
import NumberRange from './numberRange';

const apiUrl = 'https://localhost:7047/';

const EstateList = (props) => {

    const navigate = useNavigate();

    const dateToRange = {
        startDate: '01/01/2000',
        endDate: '01/01/2100',
    }
    const [dateToFilter, setDate] = useState(dateToRange);

    const firstNumber = 0;
    const secondNumber = 1000000000;

    const [firstNumberToFilter, setFirstNumber] = useState(firstNumber);
    const [secondNumberToFilter, setSecondNumber] = useState(secondNumber);

    const initialState = {
        id: '',
        name: '',
        address: '',
        description: '',
        floor: '',
        numberOfRooms: '',
        yearOfConstruction: '',
        flatArea: '',
        price: '',
        endDate: '',
    }
    const [estates, setEstates] = useState([initialState]);

    useEffect(() => getActiveEstates(), []);

    function getActiveEstates() {
        axios.get(apiUrl + 'api/estates').then(response => response.data).then(
            (result) => {
                setEstates(result)
            },
            (error) => {
                setEstates(error);
            }
        )
    }

    function showEstate(estateId) {
        navigate('/show/', { state: { estateId } });
    }

    function handleDate(event, dateToRange) {
        setDate({
            ...dateToFilter,
            startDate: dateToRange.startDate,
            endDate: dateToRange.endDate
        })
    }

    function handleNumber(event) {
        if (event.target.name === "firstNumber") {
            setFirstNumber(event.target.value)
        }
        else if (event.target.name === "secondNumber") {
            setSecondNumber(event.target.value)
        }
    }

    return (

        <div className="mt-3">
            <div className="row justify-content-end text-center">
                <div className="col-1 mt-1 fs-5">
                    Filter
                </div>
                <div className="col-1">
                    <DateRangePicker onEvent={handleDate}>
                        <button className="btn btn-secondary">Date</button>
                    </DateRangePicker>
                </div>
                <div class="col-3">
                    <NumberRange handleNumber={handleNumber}></NumberRange>
                </div>
            </div>

            <div className="row" style={{ marginTop: '40px' }}>
                {
                    estates.filter(estate => Moment(new Date(estate.endDate)) >= Moment(new Date(dateToFilter.startDate))
                        && Moment(new Date(estate.endDate)) <= Moment(new Date(dateToFilter.endDate))
                        && estate.price >= firstNumberToFilter
                        && estate.price <= secondNumberToFilter)
                        .map((item, key) => (
                            <Detail key={key} estatesData={item} showHandler={showEstate}></Detail>
                        ))
                }
            </div>
        </div>
    );
}

export default EstateList;
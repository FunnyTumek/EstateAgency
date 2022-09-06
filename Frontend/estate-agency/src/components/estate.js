import Information from "./information";
import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';

const apiUrl = 'https://localhost:7047/';

const Estate = (props) => {
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

    const location = useLocation();
    const navigate = useNavigate();

    const [formData, setFormData] = useState(initialState);
    const [estates, setEstates] = useState([initialState]);

    useEffect(() => getEstate(), []);

    function getEstate() {
        axios.get(apiUrl + 'api/estates/' + location.state.estateId).then(response => response.data).then(
            (result) => {
                setFormData(result)
            },
            (error) => {
                setFormData(error);
            }
        )
    }

    function deleteEstate(estateId) {
        axios.delete(apiUrl + 'api/estates/' + location.state.estateId).then(() => {
            setEstates(estates.filter(estate => estate.id !== estateId))
            alert('Delete successfully!');
            window.location.reload();
        }).catch();
        navigate('/');
    }

    function buyEstate(estateId) {
        axios.post(apiUrl + 'api/estates/' + location.state.estateId).then(() => {
            alert('Buy successfully!');
            setEstates(estates.filter(estate => estate.id !== estateId))
            window.location.reload();
        }).catch();
        navigate('/');
    }

    function generatePdf(estateId) {
        axios(apiUrl + 'api/estates/' + location.state.estateId + '/print', {
            method: 'POST',
            responseType: 'blob'
        })
            .then(response => {
                const file = new Blob(
                    [response.data],
                    { type: 'application/pdf' });
                const fileURL = URL.createObjectURL(file);
                window.open(fileURL);
            })
            .catch(error => {
                console.log(error);
            });
    }

    function editEstate(estateId) {
        navigate('/edit/', { state: { estateId } });
    }
    return (
        <div className="mt-4">
            <Information deleteHandler={deleteEstate} buyHandler={buyEstate} editHandler={editEstate} generatePdf={generatePdf} formData={formData}></Information>
        </div>
    );
}

export default Estate;
import FormTemplate from './formTemplate';
import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';

const apiUrl = 'https://localhost:7047/';

const EditEstate = (props) => {
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

    useEffect(() => getEstate(), []);

    function handleChange(event) {
        const name = event.target.name;
        const value = event.target.value;

        setFormData({
            ...formData,
            [name]: value
        })
    }

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

    function handleSubmit() {
        axios.put(apiUrl + 'api/estates/' + location.state.estateId, formData).then(() => {
            alert('Edit successfully!');
            setFormData(formData);
            window.location.reload();
        })
        navigate('/');
    }

    return (
        <div className="mt-4">
            <FormTemplate handleChange={handleChange} handleSubmit={handleSubmit} formData={formData} button={'Edit'} formTitle={'Edit estate'}></FormTemplate>
        </div>

    );
}

export default EditEstate;
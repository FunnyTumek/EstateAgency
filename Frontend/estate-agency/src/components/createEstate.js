import axios from 'axios';
import React, { useState } from 'react';
import FormTemplate from './formTemplate';
import { useNavigate } from 'react-router-dom';

const apiUrl = 'https://localhost:7047/';

const CreateEstate = (props) => {

    const navigate = useNavigate();

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

    const [formData, setFormData] = useState(initialState);

    function handleChange(event) {
        const name = event.target.name;
        const value = event.target.value;

        setFormData({ ...formData, [name]: value })
    }

    function handleSubmit() {
        axios.post(apiUrl + 'api/estates', formData).then(() => {
            alert('Created successfully!');
            setFormData(initialState);
            window.location.reload();
        })
        navigate('/');
    }

    return (
        <div className="mt-4">
            <FormTemplate handleChange={handleChange} handleSubmit={handleSubmit} formData={formData} button={'Add'} formTitle={'Create new estate'}></FormTemplate>
        </div>
    );
}
export default CreateEstate;
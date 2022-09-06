import { Card, ListGroup } from 'react-bootstrap';
import Moment from 'moment';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-daterangepicker/daterangepicker.css';

const Detail = (props) => {

    return (
        <Card onClick={() => props.showHandler(props.estatesData.id)} className='shadow p-2 rad' style={{ width: '21rem', marginLeft: '5%', marginRight: '2%', marginBottom: '40px' }}>
            <Card.Body>
                <Card.Title className='text-center'>{props.estatesData.name}</Card.Title>
            </Card.Body>
            <ListGroup className="list-group-flush mb-2" style={{ marginLeft: "3px" }}>
                <ListGroup.Item>Floor: {props.estatesData.floor}</ListGroup.Item>
                <ListGroup.Item>Year of Construction: {props.estatesData.yearOfConstruction}</ListGroup.Item>
                <ListGroup.Item>Flat Area: {props.estatesData.flatArea}</ListGroup.Item>
                <ListGroup.Item>Price: {props.estatesData.price}$</ListGroup.Item>
                <ListGroup.Item>Expiration Date: {(Moment(new Date(props.estatesData.endDate)).format('DD-MM-YYYY'))}</ListGroup.Item>
            </ListGroup>
        </Card>
    );
}

export default Detail;
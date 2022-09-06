import { Table, Accordion, Row, Col, Button } from 'react-bootstrap';
import Moment from 'moment';

const Information = (props) => {

    return (

        <div>
            <div className="text-center  mt-2 mb-4">
                <h2>
                    {props.formData.name}
                </h2>
            </div>
            <Row className="justify-content-md-center">
                <Col md={8}>
                    <Table>
                        <tbody>
                            <tr>
                                <th>Floor</th>
                                <td>{props.formData.floor}</td>
                            </tr>
                            <tr>
                                <th>Flat Area</th>
                                <td>{props.formData.flatArea}</td>
                            </tr>
                            <tr>
                                <th>Year Of Construction</th>
                                <td>{props.formData.yearOfConstruction}</td>
                            </tr>
                            <tr>
                                <th>Price</th>
                                <td>{props.formData.price}$</td>
                            </tr>
                            <tr>
                                <th>Expiration Date</th>
                                <td>{Moment(new Date(props.formData.endDate)).format('DD-MM-YYYY HH:MM:SS')}</td>
                            </tr>
                        </tbody>
                    </Table>
                </Col>
            </Row>

            <Row className="justify-content-md-center mt-4">
                <Col md={8}>

                    <Accordion>
                        <Accordion.Item>
                            <Accordion.Header>Description</Accordion.Header>
                            <Accordion.Body>
                                {props.formData.description}
                            </Accordion.Body>
                        </Accordion.Item>
                    </Accordion>
                </Col>
            </Row>

            <Row className="justify-content-md-center mt-4 text-center mb-4">
                <Col md={8}>
                    <Button style={{ marginRight: "10px" }} variant="success" onClick={() => props.buyHandler(props.formData.id)}>Buy</Button>
                    <Button style={{ marginRight: "10px" }} variant="info" onClick={() => props.editHandler(props.formData.id)}>Edit</Button>
                    <Button variant="danger" onClick={() => props.deleteHandler(props.formData.id)}>Delete</Button>
                    <Button variant="danger" onClick={() => props.generatePdf(props.formData.id)}>Pdf</Button>
                </Col>
            </Row>

        </div>
    );
}

export default Information;
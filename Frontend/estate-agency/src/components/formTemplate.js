import { Form, Col, Button } from 'react-bootstrap';
import Row from 'react-bootstrap/Row';
import FloatingLabel from 'react-bootstrap/FloatingLabel';

const FormTemplate = (props) => {
    return (
        <div className='mt-5'>
            <div className='text-center'>
                <h2>
                    {props.formTitle}
                </h2>
            </div>

            <Form onSubmit={props.handleSubmit} style={{ maxWidth: "800px", margin: " 5%  20% 0" }}>
                <Row className="mb-2" >
                    <Form.Group as={Col} controlId="name">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Name"
                            className="mb-1">
                            <Form.Control
                                required
                                minLength={4}
                                type="text"
                                name="name"
                                value={props.formData.name}
                                onChange={props.handleChange}
                                placeholder="Name" />
                        </FloatingLabel>
                    </Form.Group>

                    <Form.Group as={Col} controlId="address">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Address"
                            className="mb-1">
                            <Form.Control
                                required
                                minLength={4}
                                type="text"
                                name="address"
                                value={props.formData.address}
                                onChange={props.handleChange}
                                placeholder="Address" />
                        </FloatingLabel>
                    </Form.Group>
                </Row>

                <Row className="mb-2">
                    <Form.Group as={Col} controlId="numberOfRooms">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Number of Rooms"
                            className="mb-1">
                            <Form.Control
                                required
                                min={1}
                                type="number"
                                name="numberOfRooms"
                                value={props.formData.numberOfRooms}
                                onChange={props.handleChange}
                                placeholder="Number Of Rooms" />
                        </FloatingLabel>
                    </Form.Group>

                    <Form.Group as={Col} controlId="flatArea">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Flat Area"
                            className="mb-1">
                            <Form.Control
                                required
                                min={15}
                                type="number"
                                name="flatArea"
                                value={props.formData.flatArea}
                                onChange={props.handleChange}
                                placeholder="Flat Area" />
                        </FloatingLabel>
                    </Form.Group>
                </Row>

                <Row className="mb-2">
                    <Form.Group as={Col} controlId="price">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Price"
                            className="mb-1">
                            <Form.Control
                                required
                                min={1000}
                                type="number"
                                name="price"
                                value={props.formData.price}
                                onChange={props.handleChange}
                                placeholder="Price" />
                        </FloatingLabel>
                    </Form.Group>

                    <Form.Group as={Col} controlId="floor">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Floor"
                            className="mb-1">
                            <Form.Control
                                min={0}
                                type="number"
                                name="floor"
                                value={props.formData.floor}
                                onChange={props.handleChange}
                                placeholder="Floor" />
                        </FloatingLabel>
                    </Form.Group>
                </Row>

                <Row className="mb-2">
                    <Form.Group as={Col} controlId="yearOfConstruction">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Years of Construction"
                            className="mb-1">
                            <Form.Control
                                min={1800}
                                type="number"
                                name="yearOfConstruction"
                                value={props.formData.yearOfConstruction}
                                onChange={props.handleChange}
                                placeholder="Year Of Construction" />
                        </FloatingLabel>
                    </Form.Group>
                    <Form.Group as={Col} controlId="endDate">
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Expired Date"
                            className="mb-1">
                            <Form.Control
                                required
                                type="datetime-local"
                                name="endDate"
                                value={props.formData.endDate}
                                onChange={props.handleChange} />
                        </FloatingLabel>
                    </Form.Group>
                </Row>

                <Form.Group controlId="description">
                    <FloatingLabel
                        controlId="floatingInput"
                        label="Description"
                        className="mb-1">
                        <Form.Control
                            as="textarea"
                            rows={3}
                            name="description"
                            value={props.formData.description}
                            onChange={props.handleChange}
                            placeholder="description" />
                    </FloatingLabel>
                </Form.Group>

                <Form.Group className="text-center">
                    <Form.Control type="hidden" name="estateId" value={props.formData.id} />
                    <Button variant="success" type="submit" className="mt-3 text-center">{props.button}</Button>
                </Form.Group>
            </Form>
        </div>
    );
}
export default FormTemplate;
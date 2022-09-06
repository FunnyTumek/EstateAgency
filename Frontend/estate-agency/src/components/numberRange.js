import { Form, InputGroup } from 'react-bootstrap';

const NumberRange = (props) => {

    return (
        <InputGroup>
            <Form.Control
                placeholder="First number"
                aria-label="First number"
                aria-describedby="basic-addon2"
                name="firstNumber"
                type="number"
                value={props.firstNumberToFilter}
                onChange={props.handleNumber}
            />
            <Form.Control
                placeholder="Second number"
                aria-label="Second number"
                aria-describedby="basic-addon2"
                name="secondNumber"
                type="number"
                value={props.secondNumberToFilter}
                onChange={props.handleNumber}
            />
        </InputGroup>
    );
}
export default NumberRange;

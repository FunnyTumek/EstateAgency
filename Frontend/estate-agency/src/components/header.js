import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';

export const Header = (props) => {

    return (

        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="/">{props.title}</Navbar.Brand>
                <Nav className="me-auto">
                    <Nav.Link href="/create">Add Estate</Nav.Link>
                </Nav>
            </Container>
        </Navbar>

    )
}
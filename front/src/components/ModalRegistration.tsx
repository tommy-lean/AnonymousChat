import React, {useState} from "react";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import {Form} from "react-bootstrap";


export function ModalRegistration() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [registration, regShow] = useState(false);

    const registrationClose = () => regShow(false);

    const registrationOpen = () => regShow(true);



    return (
        <>
            <Button className="btn-sm" variant="warning" onClick={handleShow}>
                Вход/Регистрация
            </Button>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Регистрация</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                            <Form.Label>Ваш email</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="name@example.com"
                                autoFocus
                            />
                        </Form.Group>
                        <Form.Group
                            className="mb-3"
                            controlId="exampleForm.ControlInput1"
                        >
                            <Form.Label>Пароль</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder=""
                                autoFocus
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button className="btn-sm" variant="light" onClick={registrationClose}>
                        Вход
                    </Button>
                    <Button variant="dark">
                        Зарегистрироваться
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
}
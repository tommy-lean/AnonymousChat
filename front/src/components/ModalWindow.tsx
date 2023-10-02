import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import React, {useState} from "react";
import { Form } from 'react-bootstrap';
import {ModalAuthorization} from "./ModalAuthorization";
import axios from "axios";

export function ModalWindow() {

    const [data, setData] = useState({})

    const handleSubmit = (event: any) => {
        event.preventDefault()
        const formData = new FormData(event.target)

        axios.post('', formData)
            .then((response) => {
                setData(response.data)
            })
    }



    // --------------------------------------------------------------------
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [registration, regShow] = useState(false);

    const registrationClose = () => regShow(false);

    const registrationOpen = () => regShow(true);



    if(!registration){
        return (
            <>
                <Button className="btn-sm" variant="warning" onClick={handleShow}>
                    Вход/Регистрация
                </Button>

                <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Войти в аккаунт</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                            <Form.Group onSubmit={handleSubmit} className="mb-3" controlId="exampleForm.ControlInput1">
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
                        <Button className="btn-sm" variant="light" onClick={registrationOpen}>
                            Регистрация
                        </Button>
                        <Button variant="dark" onClick={handleClose}>
                            Войти
                        </Button>
                    </Modal.Footer>
                </Modal>
            </>
        );
    }else{
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
                            <Form.Group
                                className="mb-3"
                                controlId="exampleForm.ControlInput1"
                            >
                                <Form.Label>Ваш email</Form.Label>
                                <Form.Control
                                    type="email"
                                    placeholder="name@example.com"
                                    autoFocus
                                />
                            </Form.Group>
                            <Form.Group
                                className="mb-3"
                                controlId="exampleForm.ControlInput2"
                            >
                                <Form.Label>Пароль</Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder=""
                                    autoFocus
                                />
                            </Form.Group>
                            <Form.Group
                                className="mb-3"
                                controlId="exampleForm.ControlInput3"
                            >
                                <Form.Label>Повторите пароль</Form.Label>
                                <Form.Control
                                    type="password"
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



        // <div
        //     className="modal show"
        //     style={{ display: 'block', marginLeft: 'auto', marginTop: 'auto' }}
        // >
        //     <Modal.Dialog>
        //         <Modal.Header closeButton>
        //             <Modal.Title>Modal title</Modal.Title>
        //         </Modal.Header>
        //
        //         <Modal.Body>
        //             <p>Modal body text goes here.</p>
        //             <p>Modal body text goes here.22</p>
        //         </Modal.Body>
        //
        //         <Modal.Footer>
        //             <Button className="btn" variant="secondary">Регистрация</Button>
        //             <Button className="btn-lg" variant="primary">отмена</Button>
        //             <Button className="btn-lg" variant="primary">Продолжить</Button>
        //         </Modal.Footer>
        //     </Modal.Dialog>
        // </div>

}
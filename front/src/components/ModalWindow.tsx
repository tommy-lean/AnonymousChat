import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import React, {useState} from "react";
import { Form } from 'react-bootstrap';
import {ModalAuthorization} from "./ModalAuthorization";
import axios from "axios";
import {log} from "util";
import {Simulate} from "react-dom/test-utils";
import error = Simulate.error;

export function ModalWindow() {

    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')
    const [successMessage, setSuccessMessage] = useState('')
    const [registrationSuccess, setRegistrationSuccess] = useState(false)


    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const data = {
            login: username,
            password: password,
            gender: "string",
            name: "string",
            lastName: "string",
        };
        axios.post('https://localhost:44381/WeatherForecast/createUser', data)
            .then(response => {
                if (response && response.data) {
                    console.log(response.data);
                    setRegistrationSuccess(true)
                    setSuccessMessage('Добро пожаловать!')
                }
            })

            .catch(error => {
                if (error && error.response && error.response.data) {
                    console.log(error.response.data);
                }
            });
    };

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
                            <Form.Group  className="mb-3" controlId="exampleForm.ControlInput1">
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
                        <Modal.Title>{!registrationSuccess ? ("Регистрация") : ("Регистрация выполнена")}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        {!registrationSuccess ? (
                        <Form onSubmit={handleSubmit}>
                            <Form.Group
                                className="mb-3"
                                controlId="formBasicUser"
                            >
                                <Form.Label>Ваш email</Form.Label>
                                <Form.Control
                                    type="text"
                                    placeholder="Введите ваш email"
                                    value={username}
                                    onChange={(e) => setUsername(e.target.value)}
                                    autoFocus
                                />
                            </Form.Group>
                            <Form.Group
                                className="mb-3"
                                controlId="formBasicPassword"
                            >
                                <Form.Label>Пароль</Form.Label>
                                <Form.Control
                                    type="password"
                                    placeholder="Введите пароль"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    autoFocus
                                />
                            </Form.Group>
                            <Form.Group
                                className="mb-3"
                                controlId="exampleForm.ControlInput3"
                            >
                                <Form.Label>Повторите пароль</Form.Label>
                                <Form.Control
                                    type="password3"
                                    placeholder=""
                                    autoFocus
                                />
                            </Form.Group>
                        <Button className="btn-sm" variant="light" onClick={registrationClose}>
                            Вход
                        </Button>
                        <Button variant="dark" type="submit">
                            Зарегистрироваться
                        </Button>
                        </Form>
                            ) : (<><p className={"regSuccess"}>{successMessage}</p>
                            <div className="footer">
                                <Button className="btnReg" variant="warning">Продолжить</Button>
                            </div>

                        </>)}
                    </Modal.Body>
                    {/*<Modal.Footer>*/}
                    {/*</Modal.Footer>*/}
                </Modal>
            </>
        );
    }
}
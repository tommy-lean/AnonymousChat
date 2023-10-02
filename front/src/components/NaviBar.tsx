import React, {useState} from 'react'
import {Container, Nav, Navbar, NavDropdown} from "react-bootstrap";

export function NaviBar() {

    return (
        <>
            <Navbar bg="dark" data-bs-theme="dark">
                <Container>
                    <Navbar.Brand className='text-warning' href="#home">Chat</Navbar.Brand>
                    <Nav className="me-auto">
                        <Nav.Link href="#home">О нас</Nav.Link>
                        <Nav.Link href="#features">Контакты</Nav.Link>
                        <Nav.Link href="#pricing">Поддержка</Nav.Link>
                    </Nav>
                    <Nav>
                            <Nav.Link   href="/home">Вход/Регистрация</Nav.Link>
                    </Nav>
                </Container>
            </Navbar>
            </>
    )
}
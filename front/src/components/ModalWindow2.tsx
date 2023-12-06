import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import axios from 'axios';

function RegistrationForm() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

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
            }
        })
        .catch(error => {
            if (error && error.response && error.response.data) {
                console.log(error.response.data);
            }
        });
  };

  return (
    <Form onSubmit={handleSubmit}>
      <Form.Group controlId="formBasicUsername">
        <Form.Label>Имя пользователя</Form.Label>
        <Form.Control
          type="text"
          placeholder="Введите имя пользователя"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="formBasicPassword">
        <Form.Label>Пароль</Form.Label>
        <Form.Control
          type="password"
          placeholder="Введите пароль"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>

      <Button variant="primary" type="submit">
        Зарегистрироваться
      </Button>
    </Form>
  );
}

export default RegistrationForm;

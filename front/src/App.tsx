import React from 'react';
import {NaviBar} from "./components/NaviBar";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./App.css"
import {AboutUs} from "./components/AboutUs";
import background from "./images/secondaryBackground.jpg"
import Modal from "react-bootstrap/Modal";
import {ModalWindow} from "./components/ModalWindow";

function App() {
  return (
      <>
          <div className="backgroundImage container-fluid">
                <NaviBar></NaviBar>
                <AboutUs></AboutUs>
                <ModalWindow></ModalWindow>
          </div>
      </>
);
}

export default App;

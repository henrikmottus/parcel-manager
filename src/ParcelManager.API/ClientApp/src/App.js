import React from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home/Home';
import { Shipment } from './components/Shipment/Shipment';

export default function App(props) {
  return (
    <>
      <Route exact path='/' component={Home} />
      <Route path='/shipment/:id?' component={Shipment} />
    </>
  );
}

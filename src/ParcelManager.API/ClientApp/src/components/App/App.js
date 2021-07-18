import React from 'react';
import { Route } from 'react-router';
import { ShipmentList } from '../ShipmentList/ShipmentList';
import { Shipment } from '../Shipment/Shipment';
import { MainTitle } from './App.styled';

export default function App(props) {
  return (
    <>
      <MainTitle>Parcel Manager</MainTitle>
      <Route exact path='/' component={ShipmentList} />
      <Route path='/shipment/:id?' component={Shipment} />
    </>
  );
}

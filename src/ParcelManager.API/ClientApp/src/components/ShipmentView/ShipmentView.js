import React from 'react';
import { StyledShipment } from './ShipmentView.styled';

export function ShipmentView(props) {
  const { data } = props;

  return (
    <StyledShipment>
      <p>Shipment Number: {data.shipmentNumber}</p>
      <p>Airport : {data.airport}</p>
      <p>Flight Number : {data.flightNumber}</p>
      <p>Flight Date : {data.flightDate}</p>
      <p>Shipment is {data.isFinalized ? '' : 'NOT'} finalized</p>
    </StyledShipment>
  );
}

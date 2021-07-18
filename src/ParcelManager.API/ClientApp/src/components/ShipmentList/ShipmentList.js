import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { ShipmentView } from '../ShipmentView/ShipmentView';
import { ListItem, PageTitle } from '../shared/shared.styled';

export function ShipmentList() {
  const [items, setItems] = useState([]);

  useEffect(() => {
    fetch('/api/Shipment/')
      .then(res => res.json())
      .then(json => setItems(json.data.items));
  }, [])

  return (
    <>
    <PageTitle>Home</PageTitle>
    <ul>
      { items && items.map((el) => 
          <ListItem key={el.id}>
            <ShipmentView data={el} />
            <Link to={`shipment/${el.id}`}>Details</Link>
          </ListItem>
        )
      }
    </ul>
    </>
  );
}

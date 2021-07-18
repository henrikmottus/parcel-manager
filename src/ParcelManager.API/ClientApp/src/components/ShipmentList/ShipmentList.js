import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { ShipmentView } from '../ShipmentView/ShipmentView';
import { ListItem, PageTitle, Error } from '../shared/shared.styled';

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
    {
      items && items.length > 0
      ? <ul>
        { items.map((el) => 
            <ListItem key={el.id}>
              <ShipmentView data={el} />
              <Link to={`shipment/${el.id}`}>Details</Link>
            </ListItem>
          )
        }
      </ul>
      : <Error>There are no shipments!</Error>
    }
    
    </>
  );
}

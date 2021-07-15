import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

export function Home(props) {
  const [items, setItems] = useState([]);

  useEffect(() => {
    fetch('/api/Shipment/')
      .then(res => res.json())
      .then(json => setItems(json.data.items));
  }, [])

  return (
    <ul>
      { items && items.map((el) => 
          <li key={el.id}>
            <p>{el.shipmentNumber}</p>
            <p>{el.airport}</p>
            <p>{el.flightNumber}</p>
            <p>{el.flightDate}</p>
            <p>{el.isFinalized}</p>
            <Link to={`shipment/${el.id}`}>Details</Link>
          </li>
        )
      }
    </ul>
  );
}

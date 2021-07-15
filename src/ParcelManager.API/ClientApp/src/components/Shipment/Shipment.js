import React, { useState, useEffect } from 'react';
import { useParams } from "react-router";

export function Shipment(props) {
  const { id } = useParams();
  const [data, setData] = useState({});

  useEffect(() => {
    fetch(`/api/Shipment/${id}`)
      .then(res => res.json())
      .then(json => setData(json.data));
  }, [])

  return (
    <div>
      {
        data
          ? <>
            <p>{data.shipmentNumber}</p>
            <p>{data.airport}</p>
            <p>{data.flightNumber}</p>
            <p>{data.flightDate}</p>
            <p>{data.isFinalized}</p>
            <ul>
              {
                data.bags?.items && data.bags.items.map((el) =>
                  <li key={el.id}>
                    <p>{el.bagNumber}</p>
                    <p>{el.bagType}</p>
                    {
                      el.bagType === 'Letters'
                        ? <>
                          <p>{el.letters?.letterCount}</p>
                          <p>{el.letters?.price}</p>
                        </>
                        : <>
                          <p>{el.parcels?.items?.length}</p>
                          <p>{el.parcels?.items?.reduce((sum, el) => sum + el.price, 0)}</p>
                        </>
                    }
                  </li>
                )
              }
            </ul>
          </>
          : null
      }
    </div>
  );
}

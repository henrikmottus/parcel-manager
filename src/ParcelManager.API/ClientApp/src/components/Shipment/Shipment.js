import React, { useState, useEffect } from 'react';
import { useParams, useHistory } from "react-router";
import { ShipmentView } from '../ShipmentView/ShipmentView';
import { ListItem, PageTitle, Error } from '../shared/shared.styled';

export function Shipment() {
  const { id } = useParams();
  const [data, setData] = useState({});
  const history = useHistory();

  const goBack = () => {
    history.goBack();
  }

  useEffect(() => {
    fetch(`/api/Shipment/${id}`)
      .then(res => res.json())
      .then(json => setData(json.data));
  }, [id])

  return (
    <>
      <PageTitle>Shipment</PageTitle>
      <div>
        <button class="btn btn-link"  onClick={goBack}>Back</button >
        {
          data
          ? <>
            <ShipmentView data={data} />
            {
              data.bags?.items?.length > 0
              ? <ul>
                {
                  data.bags.items.map((el) =>
                    <ListItem key={el.id}>
                      <p> Bag Number : {el.bagNumber}</p>
                      <p> Bag Type : {el.bagType}</p>
                      <p> Number of {el.bagType} : {el[el.bagType.toLowerCase()]?.count}</p>
                      <p> Price : {el[el.bagType.toLowerCase()]?.price}</p>
                    </ListItem>
                  )
                }
              </ul>
              : <Error>The shipment has no bags!</Error>
            }
          </>
          : <Error>Shipment not found!</Error>
        }
      </div>
    </>
  );
}

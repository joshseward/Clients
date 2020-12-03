import React, { Component, useEffect, useState } from 'react';
import { Container, Row, Col, Table, Modal, ModalHeader, ModalBody, ModalFooter, Button } from 'reactstrap';

type TClient = {
  firstName: string,
  lastName: string,
  clientId: number,
  createdDate?: Date
}


const Home = () => {

  const intitalValues: TClient[] = [];
  const intitalValue: TClient = {
    clientId: 0,
    firstName: "",
    lastName: ""
  };

  const [clients, setClients] = useState(intitalValues);
  const [newClient, setNewClient] = useState(intitalValue);
  const [modal, setModal] = useState(false);

  const toggle = () => { 
    setNewClient(intitalValue);
    setModal(!modal);
  }
    const displayName = Home.name;

    useEffect(() => {
    const requestOptions = {
        method: 'GET'
    };

      fetch(`api/Client`, requestOptions)
      .then((response: any) => {
        setClients(response)
      });
    }, [])

    const deleteClient = async (clientId: number)  => {
      const requestOptions = {
        method: 'DELETE'
      };

      fetch(`api/Client/${clientId}`, requestOptions)
      .then((response: any) => {
        if(response){
          setClients(clients.filter(x => x.clientId != clientId));
        }
      });
    }        
    

    const save = async (client: TClient)  => {
      const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(client)
      };

      fetch(`api/Client`, requestOptions)
      .then((response: any) => {        
      });
    }    
    
    const add = async ()  => {
      const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newClient)
      };

      fetch(`api/Client`, requestOptions)
      .then((response: any) => {
        clients.push(newClient)
        setClients(clients)  
      });
    }    
    

    return (
        <div>
          <Modal isOpen={modal} toggle={toggle}>
            <ModalHeader toggle={toggle}>Add</ModalHeader>
            <ModalBody>
              <Container>
                <Row>
                  <Col>
                    <label>First Name</label>
                    <input type="text" value={newClient.firstName} />
                  </Col>
                  <Col>
                    <label>First Name</label>
                    <input type="text" value={newClient.lastName} />
                  </Col>
                </Row>
              </Container>
            </ModalBody>
            <ModalFooter>
              <Button onClick={() => add}>Add</Button>
            </ModalFooter>
          </Modal>
          <Container>
            <Row>
              <Col>
              <button onClick={() => toggle}>Add Client</button>
              </Col>
            </Row>      
            <Row>              
              <Col>
              <Table>
      <thead>
        <tr>
          <th>#</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {clients.map(x => {
          <tr>
            <th>{x.clientId}</th>
            <td><input type="text" value={x.firstName} /></td>
            <td><input type="text" value={x.lastName} /></td>
            <td><Button onClick={() => deleteClient(x.clientId)}>Delete</Button> <Button onClick={() => save(x)}>Save</Button> </td>
          </tr>  
        })}              
      </tbody>
    </Table>
              </Col>              
            </Row>
          </Container>
       </div>
    );
}

export default Home

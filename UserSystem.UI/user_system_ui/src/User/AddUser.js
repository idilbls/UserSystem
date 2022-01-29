import React from 'react';  
import axios from 'axios';  
import '../User/AddUser.css'  
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';  
const MilitaryStatus = {
  Exempted : 1,
  Postponed: 2,
  Done:3
};
class AddUser extends React.Component{  

constructor(props){  
  super(props)  
  this.createUser = this.createUser.bind(this);  
  this.state = {  
    name:'',  
    surname:'', 
    description:'', 
    militaryStatus: 0
  }  
}   
async createUser(){  
await  axios.post('https://localhost:44388/api/user/add/', 
{   id: 0,
    name: this.state.name,
    surname: this.state.surname,
    description: this.state.description,
    militaryStatus:  this.state.militaryStatus})  
.then(json => {  
if(json.data.StatusCode===200){  
  console.log(json.data.Status);  
  alert("Data Save Successfully");  
this.props.history.push('/UserList')  
}  
else{  
alert('Data not Saved');  
debugger;  
this.props.history.push('/UserList')  
} 
this.props.history.push('/UserList')  
})  
} 

// createUser(e){ 
//   e.preventDefault();  
//   const obj = {
//     id: 0,
//     name: this.state.name,  
//     surname: this.state.surname,  
//     email: this.state.email,  
//     phoneNumber: this.state.phoneNumber,
//     dateOfBirth: this.state.dateOfBirth
//   };
//    axios.post('https://localhost:44399/api/user/add/', {obj})  
//   .then(res => console.log(res.data));  
//   this.props.history.push('/UserList')  
// }

handleChange= (e)=> {  
this.setState({[e.target.name]:e.target.value});  
}  
   
render() {  
return (  
   <Container className="App">  
    <h4 className="PageHeading">Enter User Informations</h4>  
    <Form className="form" onSubmit={this.createUser}>  
      <Col>  
        <FormGroup row className="p-4 pb-0">  
          <Label for="name" sm={2}>Name</Label>  
          <Col sm={10}>  
            <Input type="text" name="name" onChange={this.handleChange} value={this.state.name} placeholder="Enter Name" required/>  
          </Col>  
        </FormGroup>  
        <FormGroup row className="p-4 pb-0">  
          <Label for="surname" sm={2}>Surname</Label>  
          <Col sm={10}>  
            <Input type="text" name="surname" onChange={this.handleChange} value={this.state.surname} placeholder="Enter Surname" required/>  
          </Col>  
        </FormGroup>  
        <FormGroup row className="p-4 pb-0">  
          <Label for="description" sm={2}>Description</Label>  
          <Col sm={10}>  
            <Input type="text" name="description" onChange={this.handleChange} value={this.state.email} placeholder="Enter Description" required/>  
          </Col>  
        </FormGroup>  
        <FormGroup row className="p-4 pb-0">  
          <Label for="militaryStatus" sm={2}>Military Status</Label>  
          <Col sm={10}>  
            <Input type="text" name="militaryStatus" onChange={this.handleChange} value={this.state.phoneNumber} placeholder="Enter Military Status" required/>  
          </Col>  
        </FormGroup>   
      </Col>  
      <Col>  
        <FormGroup row className="mt-4">  
          <Col sm={5}>  
          </Col>  
          <Col sm={1}>  
          <Button type="submit" color="success">Submit</Button>{' '} 
          </Col>  
          <Col sm={1}>  
            <Button color="danger">Cancel</Button>{' '}  
          </Col>  
          <Col sm={5}>  
          </Col>  
        </FormGroup>  
      </Col>  
    </Form>  
  </Container>  
);  
}  
   
}  
   
export default AddUser;  
   
import React from 'react';   
import { Container, Col, Form, Row, FormGroup, Label, Input, Button } from 'reactstrap';  
import axios from 'axios'  
import '../User/AddUser.css'  
class Edit extends React.Component {  
    constructor(props) {  
        super(props)  
     
    this.onChangeName = this.onChangeName.bind(this);  
    this.onChangeSurname = this.onChangeSurname.bind(this);  
    this.onChangeDescription = this.onChangeDescription.bind(this);  
    this.onChangeMilitaryStatus = this.onChangeMilitaryStatus.bind(this);  
    this.onSubmit = this.onSubmit.bind(this);  
  
    this.state = {  
        name:'',  
        surname:'', 
        description:'', 
        militaryStatus:0
      }  
    }  
  
  componentDidMount() {  
      axios.get('https://localhost:44388/api/user/get_user_by_id?id='+this.props.match.params.id)  
          .then(response => {  
              this.setState({ 
                name:response.data.result.name,
                surname:response.data.result.surname,  
                description:response.data.result.description, 
                militaryStatus:response.data.result.militaryStatus 
             });  
             console.log(response.data);
  
          })  
          .catch(function (error) {  
              console.log(error);  
          })  
    }  
  
  onChangeName(e) {  
    this.setState({  
        name: e.target.value  
    });  
  }  
  onChangeSurname(e) {  
    this.setState({  
        surname: e.target.value  
    });    
  }  
  onChangeDescription(e) {  
    this.setState({  
        description: e.target.value  
    });  
}  
    onChangeMilitaryStatus(e) {  
        this.setState({  
            militaryStatus: e.target.value  
        });  
  }  

  
  onSubmit(e) {   
       e.preventDefault();  
    const obj = {  
      id:this.props.match.params.id,  
      name: this.state.name, 
      surname: this.state.surname,  
      description: this.state.description,  
      militaryStatus: this.state.militaryStatus
  
    };  
    axios.post('https://localhost:44388/api/user/update/', obj)  
        .then(res => console.log(res.data));  
        this.props.history.push('/UserList')  
  }  
    render() {  
        return (  
            <Container className="App">  
  
             <h4 className="PageHeading">Update User Informations</h4>  
                <Form className="form" onSubmit={this.onSubmit}>  
                    <Col>  
                        <FormGroup row className="p-4 pb-0">  
                            <Label for="name" sm={2}>Name</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="name" value={this.state.name} onChange={this.onChangeName}  
                                placeholder="Enter Name" />  
                            </Col>  
                        </FormGroup>  
                        <FormGroup row className="p-4 pb-0">  
                            <Label for="surname" sm={2}>Surname</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="surname" value={this.state.surname} onChange={this.onChangeSurname} placeholder="Enter Surname" />  
                            </Col>  
                        </FormGroup>  
                         <FormGroup row className="p-4 pb-0">  
                            <Label for="description" sm={2}>Description</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="description" value={this.state.description} onChange={this.onChangeDescription} placeholder="Enter Description" />  
                            </Col>  
                        </FormGroup>  
                         <FormGroup row className="p-4 pb-0">  
                            <Label for="militaryStatus" sm={2}>Military Status</Label>  
                            <Col sm={10}>  
                                <Input type="text" name="militaryStatus"value={this.state.militaryStatus} onChange={this.onChangeMilitaryStatus} placeholder="Enter Military Status" />  
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
  
export default Edit;  
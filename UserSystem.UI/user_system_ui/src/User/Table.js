import React, { Component } from 'react';  
import axios from 'axios';  
import { Link } from 'react-router-dom';  
class Table extends Component {  
  constructor(props) {  
    super(props);  
    }  

    DeleteUser= () =>{  
      axios.delete('https://localhost:44388/api/user/delete?id='+this.props.obj.id)  
     .then(json => {  
     if(json.data.Status==='Delete'){  
     alert('Record deleted successfully!!');  
     }  
     })  
     }  
  render() {  
    return (  
        <tr>  
          <td>  
            {this.props.obj.id}  
          </td>  
          <td>  
            {this.props.obj.name}  
          </td>  
          <td>  
            {this.props.obj.surname}  
          </td>  
          <td>  
            {this.props.obj.description}  
          </td>  
          <td>  
            {this.props.obj.militaryStatus}  
          </td> 
          <td>  
            {this.props.obj.dateOfRegistration}  
          </td>   
          <td>  
          <Link to={"/edit/"+this.props.obj.id} className="btn btn-success">Edit</Link>  
          </td>  
          <td>  
            <button type="button" onClick={this.DeleteUser} className="btn btn-danger">Delete</button>  
          </td>  
        </tr>  
    );  
  }  
}  
  
export default Table;  
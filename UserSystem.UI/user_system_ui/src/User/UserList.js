import axios from "axios";
import React,{Component} from "react";
import Table from './Table';  


export class UserList extends Component{

    constructor(props) {  
        super(props);  
        this.state = {users: []};  
      } 
      
      componentDidUpdate() {
        const url = "https://localhost:44388/api/user/get_all";
        const response =  axios.get(url,{ params: { currentPage: 1 } })
        .then(response=>{
            this.setState({users: response.data.result.users});
        })
        .catch(function (error){
            console.log(error);
        })
      }

 componentDidMount(){
    const url = "https://localhost:44388/api/user/get_all";
    const response =  axios.get(url,{ params: { currentPage: 1 } })
    .then(response=>{
        this.setState({users: response.data.result.users});
    })
    .catch(function (error){
        console.log(error);
    })
}

tabRow(){  
    return this.state.users.map(function(object, i){  
        return <Table obj={object} key={i} />;  
    });  
  }  

    render(){
        return(
                <div>   
                    <h4 align="center">User List</h4>  
          <table className="table table-striped" style={{ marginTop: 10 }}>  
            <thead>  
              <tr>  
                <th>Id</th>  
                <th>Name</th>  
                <th>Surname</th>  
                <th>Description</th>  
                <th>MilitaryStatus</th> 
              <th colSpan="4">Action</th>  
              </tr>  
            </thead>  
            <tbody>  
             { this.tabRow() }   
            </tbody>  
          </table>  
        </div> 
        )
    }
}
export default UserList;  
   
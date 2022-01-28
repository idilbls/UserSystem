import './App.css';
import AddUser from './User/AddUser';  
import UserList from './User/UserList';  
import UpdateUser from './User/UpdateUser'; 
import {BrowserRouter as Router, Route, Switch, Link} from 'react-router-dom';

function App() {
  return (
    <Router>  
      <div>  
      <nav className="navbar navbar-expand navbar-dark bg-dark p-2">
            <a href="/UserList" className="navbar-brand">
              User System
            </a>
            <div className="navbar-nav mr-auto">
              <li className="nav-item">
                <Link to={"/UserList"} className="nav-link">
                  User List
                </Link>
              </li>
              <li className="nav-item">
                <Link to={"/AddUser"} className="nav-link">
                  Add User
                </Link>
              </li>
            </div>
          </nav>
          <div className="container mt-3">
          <Switch>  
          <Route exact path='/AddUser' component={AddUser} />  
          <Route path='/edit/:id' component={UpdateUser} />  
          <Route path='/UserList' component={UserList} />  
        </Switch>
          </div>  
      </div>  
    </Router>  


  );
}

export default App;

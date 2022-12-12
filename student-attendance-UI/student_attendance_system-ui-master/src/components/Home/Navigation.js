import React from "react";
import { NavLink } from "react-router-dom";
import { Navbar, Nav } from "react-bootstrap";
import { useHistory} from "react-router-dom";
import Logo from "../../Images/logo.jpg";
 function Navigation() {
   const history = useHistory();
     function logout() {
     sessionStorage.clear();
     history.push("/Home");
     window.location.reload(true);
   }
  let user = sessionStorage.getItem("user-info");  
  if (user == "admin"){
  return (
    <header>
    <Navbar bg="dark" variant="tabs">
    <Navbar.Brand href="/">Admin</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav"/>
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="ml-auto flex-grow-1 justify-content-evenly">
          <Nav.Link className="d-inline p-2 bg-dark text-white" to="/Home">Home</Nav.Link>
          <NavLink className="d-inline p-2 bg-dark text-white" to="/Admin/AddStudent" style={{textDecoration:"none"}} >Add Student</NavLink>
         <NavLink className="d-inline p-2 bg-dark text-white"to="/Admin/ViewStudentAttendance" style={{textDecoration:"none"}} >View Student Attendance</NavLink>
          <NavLink className="d-inline p-2 bg-dark text-white" to="/Admin/ViewStudentLeave" style={{textDecoration:"none"}} >View Student Leave</NavLink>
          </Nav>
          <Nav className="ms-auto">
              <Nav.Link onClick={logout}>LogOut</Nav.Link>
          </Nav>
      </Navbar.Collapse>
    </Navbar>
    </header>
  );
  }
  else if (user == "student") {
    return (
      <header>

  <Navbar bg="dark"variant="dark" >
          <Navbar.Brand href="/">Student</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav"/>
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav>
          <NavLink className="d-inline p-2 bg-dark text-white" to="/Home">Home</NavLink>
          
          <NavLink className="d-inline p-2 bg-dark text-white"to="/MarkAttendance" style={{ textDecoration: 'none' }}>Mark Attendance</NavLink>
          <NavLink className="d-inline p-2 bg-dark text-white" to="/ApplyLeave" style={{ textDecoration: 'none' }} >Apply Leave</NavLink>
          </Nav>
          <Nav className="ms-auto">
          <Nav.Link onClick={logout}>LogOut</Nav.Link>
          </Nav>
      </Navbar.Collapse>
    </Navbar>

  </header>
  );
}
else {
  
  return (
    <header>
      
      <Navbar bg="dark" variant="dark" className="p-0" >
      <Navbar.Brand href="/">
        <img src={Logo} height="55vh" margin="0"/>
        
        </Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav"/>
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="ms-auto"> 
          <NavLink className="d-inline p-2 bg-dark text-white" to="/Home" style={{textDecoration:'none', margin:' 0 1em'}}>Home</NavLink>
          <NavLink className="d-inline p-2 bg-dark text-white" to="/Login" style={{textDecoration:'none', margin:' 0 1em' }}>Login</NavLink>
          </Nav>
          </Navbar.Collapse>
          </Navbar>
      </header>
  );
}
}
export default Navigation;

import { useHistory } from "react-router-dom";
import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import {Form, Alert} from "react-bootstrap";
import LoginImg from "../../Images/login.png"
import swal from 'sweetalert';

function Login()
{
  const[username,setUsername]=useState("");
  const[password,setPassword]=useState("");
  const[studentType,setStudentType]=useState("");
   const history = useHistory();

   useEffect(()=>{
     if(sessionStorage.getItem("user-info")){
       history.push("/Admin/AddStudent")
      //  window.location.reload(true)
     }
   }, [])

  async function login(e){
    console.log('inside login fn')
    console.log('e.target.value')
    console.log(studentType)
     e.persist();
     e.preventDefault();
    //  debugger;
    // let employeeType = studentType
     let item ={username, password, studentType};
     console.log("consoling item",item);
     console.log(JSON.stringify(item));
     if(!username){
       alert("hi")
     }
     let result = await fetch("https://localhost:44381/api/Accounts/Login", {
       method: 'POST',
       headers:{
        'Accept': 'application/json',
        'Content-Type': 'application/json'
        },
        
        body: JSON.stringify(item)
       
      });
      result = await result.json();
      console.log(result)
      console.log(result.token);
      // console.log("printing res msg",result.responseMsg);
      if(result.token === null)
      {
         swal("Invalid Credentials","Login Failed","error");
      }
      else{
      swal("Login Success","User Authorised", "success");
      sessionStorage.setItem("auth-token",JSON.stringify(result))
      sessionStorage.setItem("user-info", studentType)
      window.location.reload(true);
      }
     }
   return (
    <div>
      <form>
        <div className="logo">
          <h1 className="text-center">Login</h1>
          <img
            src={LoginImg}
            className="img-circle"
            alt="Cinque Terre"
            width="100"
            height="100"
          />
        </div>
        <br />
        <div class="form-group">
          <label for="name">User Name:</label>
          <input
            type="text"
            name="username"
            placeholder="Enter Username" required 
            onChange={(e)=>setUsername(e.target.value)}
            id="username" 
          />
        </div>
        <br />
        <div class="form-group">
          <label for="password">Password:</label>
          <input
            type="password"
            name="password"
            placeholder="Enter password" required
            onChange={(e)=>setPassword(e.target.value)}
            id="password" 
          />
        </div>
        <br />
        <div class="form-group">
          <label for="role">Role:</label>

          {/* <select
            // type="role"
            name="role"
            className="form-control"
            // placeholder="--select--"
            onChange={(e)=>setStudentType(e.target.value)}
            value={studentType}
          >

          <option value="admin">Admin</option>
          <option value="student">Student</option>
            
          </select> */}

          <Form.Select name="role" value={studentType}  onChange={ (e)=> {setStudentType(e.target.value)} }>
          <option value="admin">Admin</option>
          <option value="student">Student</option>
          </Form.Select>
          <p>{studentType}</p>
        </div>
        <br />
         <center>
          <button 
          type="submit"
          name="Login"
          onClick={login}
          className="btn btn-dark btn-lg btn-block"
        >
          Login
        </button>
        </center>

        <p className="forgot-password text-center">
          <Link to="Password" className="formFieldLink">
            <div href="#" style={{textDecoration:"none", color:"red"}}>Forgot password?</div>
          </Link>
        </p>
        
      </form>
    </div>
  );
}

export default Login;

import React, { useState } from "react";
import axios from "axios";
import { useHistory, Link } from "react-router-dom";
import swal from 'sweetalert';

const AddStudent = () => {
  let history = useHistory();
  const [user, setUser] = useState({
    id: "",
    name: "",
    email: "",
    tel: "",
    gender: "",
    username: "",
    password: "",
  });

  const data = {
    studentId: user.id,
    studentName: user.name,
    studentGender: user.gender,
    studentEmail: user.email,
    studentContact: user.tel,
    studentUsername: user.username,
    studentPassword: user.password,
    studentType: "Student",
  };
  console.log(data);
  const onInputChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };
  const onSubmit = async (e) => {
    e.preventDefault();
    console.log(data)
    await 
      axios.post("https://localhost:44381/api/Students/CreateStudent", data)
      .then((response) =>{
        swal("Registered","Student Registered","success");
        history.push("/Admin/StudentDetails");
       console.log(response.data)
      })
      .catch(error => {
        console.log(error)
      swal("Registration Failed","Invalid data","error");
     });
  
  };

  return (
    <div>
      <center>
        <h1>Student Registration</h1>
      </center>
      <div className="form">
        <form onSubmit={(e) => onSubmit(e)}>
          <label>Student Id</label>
          <input
            type="text"
            name="id"
            value={user.id}
            className="form-control"
            placeholder=" Enter Student Id"
            required
            onChange={(e) => onInputChange(e)}
          />
          <label>Student Name</label>
          <input
            type="text"
            name="name"
            value={user.name}
            className="form-control"
            placeholder="Enter Name"
            required
            onChange={(e) => onInputChange(e)}
          />
          <label>Student Email</label>
          <input
            type="email"
            name="email"
            value={user.email}
            className="form-control"
            placeholder="Enter Email"
            required
            onChange={(e) => onInputChange(e)}
          />
          <label>Student PhoneNumber</label>
          <input
            type="tel"
            name="tel"
            value={user.tel}
            className="form-control"
            placeholder="Enter PhoneNumber"
            required
            onChange={(e) => onInputChange(e)}
          />
          <label> Gender :</label>
          <br />
          <input
            type="radio"
            value="Male"
            data-cke-saved-name="gender"
            name="gender"
            onChange={(e) => onInputChange(e)}
          />
          Male
          <input
            type="radio"
            value="Female"
            data-cke-saved-name="gender"
            name="gender"
            onChange={(e) => onInputChange(e)}
          />
          Female
          <br />
          <label>Student Username</label>
          <input
            type="text"
            className="form-control"
            placeholder="Enter Username"
            name="username"
            value={user.username}
            required
            onChange={(e) => onInputChange(e)}
          />
          <label>Student Password</label>
          <input
            type="password"
            className="form-control"
            placeholder="Enter Password"
            name="password"
            // value={user.password}
            required
            onChange={(e) => onInputChange(e)}
          />
          <br />
          <div class="inputbox">
            <input type="submit" value="Register" />
            &nbsp;  &nbsp;  &nbsp;  &nbsp;
          <button type="button" class="btn btn-outline-info btn-lg">
          <Link to="StudentDetails" className="formFieldLink">
          <a href="/StudentDetails">View</a>
          </Link>
         </button>
         </div>
        </form>
      </div>
    </div>
  );
};
export default AddStudent
import "./App.css";
import React from "react";
import Home from "./components/Home/Home";
import Navigation from "./components/Home/Navigation";
import { BrowserRouter as Router, Route } from "react-router-dom";
import Login from "./components/Home/Login";
import AddStudent from "./components/Admin/AddStudent";
import UpdateStudent from "./components/Admin/UpdateStudent";
import StudentDetails from "./components/Admin/StudentDetails";
import ViewStudentAttendance from "./components/Admin/ViewStudentAttendance";
import ViewStudentLeave from "./components/Admin/ViewStudentLeave";
import ApplyLeave from "./components/Student/ApplyLeave";
import MarkAttendance from "./components/Student/MarkAttendance";

function App() {
  let userType = sessionStorage.getItem("user-info");
  return (
    <div className="App">
      <Router>
        <Navigation />
        <Route exact path="/" component={Home}></Route>
        {userType === "admin" && (
          <Route
            exact
            path="/Admin/AddStudent"
            component={AddStudent}
          ></Route>
        )}
        
        {userType === "admin" && (
          <Route
            exact
            path="/Admin/StudentDetails"
            component={StudentDetails}
          ></Route>
        )}
        <Route exact path="/Admin/UpdateStudent" component={UpdateStudent}></Route>
        <Route
          exact
          path="Student"
          component={ViewStudentAttendance}
        ></Route>
        <Route
          exact
          path="/Admin/ViewStudentAttendance"
          component={ViewStudentAttendance}
        ></Route>
        <Route
          exact
          path="/Admin/ViewStudentLeave"
          component={ViewStudentLeave}
        ></Route>
        <Route exact path="/ApplyLeave" component={ApplyLeave}></Route>
        <Route exact path="/MarkAttendance" component={MarkAttendance}></Route>
        <Route exact path="/Home" component={Home}></Route>
        <Route exact path="/Login" component={Login}></Route>
      </Router>
    </div>
  );
}

export default App;

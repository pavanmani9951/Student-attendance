import React, { useState, useEffect } from "react";
import { useHistory , withRouter , BrowserRouter} from "react-router-dom";
import { Table } from "react-bootstrap";
import StudentService from "../DBServices/StudentService";
import swal from 'sweetalert';
function StudentDetails(props) {
  let history = useHistory();
  const [data, getData] = useState([]);
   useEffect(() => {
    const GetData = async () => {
      StudentService.getAllStudents().then((result) => {
        getData(result.data);
      });
    };
    GetData();
  }, []);
  
   const deleteStudent = (id) => {
   StudentService.deleteStudent(id)
      .then((resData) => {
        swal("Warning","Are you sure you want to do this?","warning" ,{buttons: ["Yes","No"]});
         swal("Deleted","Student deleted successfully","success");
        // history.push("/Admin/StudentDetails");
        // this.setState({ data: resData.data.result });
        const GetData = async () => {
          StudentService.getAllStudents().then((result) => {
           getData(result.data);
            
            });
          };
        GetData();
        // alert("Deleted Successfully");
        // history.push("/Admin/StudentDetails");
        props.history.push({
          pathname: '/Admin/StudenDetails'
      });
     });
  };
  const UpdateStudent = (id) => {
    props.history.push({
        pathname: '/Admin/UpdateStudent'
    });
  };
  return (
    <div>
      <BrowserRouter forceRefresh={true}></BrowserRouter>
      <center>
        <h1>Student Details </h1>
      </center>
      <Table striped bordered hover variant="dark">
        <thead>
          <tr>
            <th>Student Id</th>
            <th>Student Name</th>
            <th>Student Gender</th>
            <th>Student Email</th>
            <th>Student PhoneNumber</th>
            <th>Student Username</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {data &&
            data.length > 0 &&
            data.map((item, idx) => {
              return (
                <tr key={idx}>
                  <td>{item.studentId}</td>
                  <td>{item.studentName}</td>
                  <td>{item.studentGender}</td>
                  <td>{item.studentEmail}</td>
                  <td>{item.studentContact}</td>
                  <td>{item.studentUsername}</td>
                  <td>
                    <div className="btn-group">
                      <button
                      className="btn btn-warning"
                      onClick={() => (UpdateStudent(item.studentId))}
                      >
                      Update
                      </button>
                      
                      <button
                        className="btn btn-danger"
                        onClick={() => (deleteStudent(item.studentId))}
                      >
                      Delete
                      </button>
                    </div>
                  </td>
                </tr>
              );
            })}
        </tbody>
      </Table>
    </div>
    
  );
}

export default withRouter (StudentDetails);

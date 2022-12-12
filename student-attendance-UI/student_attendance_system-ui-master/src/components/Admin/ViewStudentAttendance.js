import React, { useState, useEffect } from "react";
import AttendanceService from "../DBServices/AttendanceService";
import {Table} from "react-bootstrap";
import moment from 'moment';

function ViewStudentAttendance() {
const [data, getData] = useState([]);
  useEffect(() => {
    GetData();
  }, []);
  const GetData = () => {
    AttendanceService.getAllAttendances().then((result) => {
      getData(result.data);
      console.log(result.data);
      });
  };
  return (
    <div>
      <center>
      <h1 style={{ color: "black" }}>View Student Attendance</h1>
      </center>
      <html>
      <Table striped bordered hover variant="dark">
          <thead>
            <tr>
              <th>Student Id</th>
              <th>Attendance Date</th>
              <th>Attendance Status</th>
            </tr>
          </thead>
          <tbody>
            {data &&
              data.length > 0 &&
              data.map((item, idx) => {
                return (
                  <tr key={idx}>
                    <td>{item.studentId}</td>
                    <td>{moment(item.attendanceDate).format("YYYY-MM-DD")}</td>
                    <td>{item.attendanceStatus}</td>
                  </tr>
                );
              })}
          </tbody>
        </Table>
      </html>
    </div>
  );
}
export default ViewStudentAttendance;

import React, { useState } from "react";
import moment from 'moment';
import axios from "axios";
import { useHistory } from "react-router-dom";
import swal from 'sweetalert';
//const currentDate = new Date()
//const currentDateFromat = `${currentDate.getFullYear()}-${currentDate.getMonth()+1}-${new Date().toLocaleDateString().split('/')[1]}`
//console.log(currentDateFromat);  
const newDate = moment(new Date().toLocaleDateString()).format('YYYY-MM-DD')
//console.log(newDate);
const MarkAttendance = () => {
  let history = useHistory();
  const [user, setUser] = useState({
    attendanceId:"",
    id: "",
    date: "",
    status: "",
    student:null
  });
  const data = {
    attendanceId:user.attendanceId,
    studentId: user.id,
    attendanceDate: user.date,
    attendanceStatus: user.status,
    students:user.students,
  };
  console.log(data);
  const onInputChange = (e) => {
  setUser({ ...user, [e.target.name]: e.target.value });
  };

  const onSubmit = async (e) => {
    e.preventDefault();
    const count = await axios({method: 'get',url: 'https://localhost:44381/api/Attendances/GetAttendances'});
    user.attendanceId ='A'.concat(count.data.length.toString());
    console.log(count.data.length.toString());
    data.attendanceId='A'.concat(count.data.length.toString());
    data.attendanceDate = newDate;
    console.log(data);
    axios({method: 'post',url: 'https://localhost:44381/api/Attendances/CreateAttendance',data: data})
    .then(res=>console.log(res));
    swal("Good Job","Attendance Marked","success");
    history.push("/Home");
  };
  return (
    <div>
      <center>
        <h1>Mark Attendance</h1>
      </center>
      <html>
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
            <label>Date</label>
            <input
              type="date"
              name="date"
              value= {newDate}
              min={newDate} 
              max={newDate}
              className="form-control"
              placeholder="dd/mm/yyyy"
              onChange={(e) => onInputChange(e)}
            />
            <label>Attendance Status :</label>
            <br />
            <input
              type="radio"
              name="status"
              value="Present"
              data-cke-saved-name="status"
              onChange={(e) => onInputChange(e)}
            />
            Present
            <input
              type="radio"
              name="status"
              value="Absent"
              data-cke-saved-name="status"
              onChange={(e) => onInputChange(e)}
            />
            Absent
            <br />
            <center>
              <button type="submit" className="btn btn-success">
                Submit
              </button>
            </center>
          </form>
        </div>
      </html>
    </div>
  );
};
export default MarkAttendance;

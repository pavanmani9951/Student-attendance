import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import axios from "axios";
import LeaveService from "../DBServices/LeaveService";
import swal from 'sweetalert';
import moment from 'moment';
const newDate = moment(new Date().toLocaleDateString()).format('YYYY-MM-DD')
const ApplyLeave = () => {
  let history = useHistory();
  const [user, setUser] = useState({
    id: "",
    leavedate: "",
    startdate: "",
    enddate: "",
    leavereason: "",
  });
  
  const onInputChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
  };
  // const onSubmit = async (e) => {
  //   e.preventDefault();
    // console.log(data);
  //   LeaveService.createLeave(data).then((result) => {
  //   alert("Leave Applied")
  //   history.push("/Home");
  // });
  const onSubmit = async (e) => {
    e.preventDefault();
    const count = await axios({method: 'get',url: 'https://localhost:44381/api/Leaves/GetLeaves'});
    user.LeaveId ='L'.concat(count.data.length.toString());
    console.log(count.data.length.toString());
    const data = {
      leaveApplyDate: newDate,
      leaveStartDate: user.startdate,
      leaveEndDate: user.enddate,
      leaveReason: user.leavereason,
      studentId:user.id,
    };
    data.LeaveId='L'.concat(count.data.length.toString());
    
  //   
    axios({method: 'post',url: 'https://localhost:44381/api/Leaves/CreateLeave',data})
    .then(res=>console.log(res));
    swal("Good Job","Leave Marked","success");
    history.push("/Home");
  };



  return (
    <html>
      <h5 style={{ color: "black" }}>Apply Leave</h5>
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
          <label>Apply Leave Date</label>
          <input
            type="date"
            name="leavedate"
            value={newDate}
            min={newDate} 
            max={newDate}
            className="form-control"
            placeholder="dd/mm/yyyy"
            onChange={(e) => onInputChange(e)}
          />
          <label>Start Date</label>
          <input
            type="date"
            name="startdate"
            value={user.startdate}
            min={newDate} 
            className="form-control"
            placeholder="dd/mm/yyyy"
            onChange={(e) => onInputChange(e)}
          />
          <label>End Date</label>
          <input
            type="date"
            name="enddate"
            min={newDate}
            value={user.enddate}
            className="form-control"
            placeholder="dd/mm/yyyy"
            onChange={(e) => onInputChange(e)}
          />
          <br />
          <label>Leave Reason</label>
          <input
            type="textarea"
            name="leavereason"
            value={user.leavereason}
            className="form-control"
            placeholder="Enter Reason"
            onChange={(e) => onInputChange(e)}
          />
          <br />
          <button type="submit" className="btn btn-primary ">
            Apply Leave
          </button>
        </form>
      </div>
    </html>
  );
};

export default ApplyLeave;

import axios from 'axios';
const baseUrl = "https://localhost:44381/api/Attendances/";
export const AttendanceService = {
    getAllAttendances,     
    getAttendanceById,    
    createAttendance,
    updateAttendance,
    deleteAttendance
};
function getAllAttendances(){ 
return axios.get(baseUrl+"GetAttendances");
    
}

function getAttendanceById(id){
    return axios.get(baseUrl +"GetAttendance/"+ id);
}

function createAttendance(AttendanceObj){
    return axios.post(baseUrl+"CreateAttendance", AttendanceObj);
}


function updateAttendance(AttendanceObj){
    return axios.put(baseUrl + "UpdateAttendance", AttendanceObj);
}

function deleteAttendance(id){
    return axios.delete(baseUrl + "DeleteAttendance"+ id);
}

export default AttendanceService;

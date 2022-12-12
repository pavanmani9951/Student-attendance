import axios from 'axios';

const baseUrl = "https://localhost:44381/api/Student/";

export const StudentServices = {
    getAllStudents,     
    getStudentById,    
    createStudent,
    updateStudent,
    deleteStudent
};


function getAllStudents(){  
    return axios.get("https://localhost:44381/api/Students/GetStudents");
    
}

function getStudentById(id){
    return axios.get(baseUrl+"GetStudent/" + id);
}

function createStudent(StudentObj){
    return axios.post("https://localhost:44381/api/Students/CreateStudent");
}


function updateStudent(StudentObj){
    
    return axios.put(baseUrl +"UpdateStudent", StudentObj);
}

function deleteStudent(id){
    return axios.delete("https://localhost:44381/api/Students/DeleteStudent/" + id);
}

export default StudentServices;

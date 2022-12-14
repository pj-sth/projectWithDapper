import { useEffect, useState } from 'react';
import axios from 'axios';
import { useFormik } from 'formik';
import "./AddStudentModal.css";


const AddStudentModal = ({ modal, setModal }) => {

    const [students, setStudents] = useState([]);
    const [subjects, setSubjects] = useState([]);

    
  
    useEffect(() => {
        axios.get("https://localhost:7139/api/Student").then((response) => {
            setStudents((data) => {
                return response.data;
            })
        })
      axios.get("https://localhost:7139/api/Subject").then((response) => {
        setSubjects((data) => {
          return response.data;
        })
      })
    }, []);

    const onSubmit = (values, actions) => {
        var payload = {
            studentid: values.studentname,
            subjectids: values.subjectname
        };
        actions.resetForm();
        axios.post("https://localhost:7139/api/StudentSubject",payload).then((response) =>{
            window.location.reload();
        })
    }

    const { values, handleBlur, handleChange, handleSubmit } = useFormik({
        initialValues: {
            studentname: "",
            subjectname: []
        },
        onSubmit
    })

    const handleClose = () => {
        setModal("close");
    }

  return (
    <>
        {/* <div id="studentModal" className={`addStudentModal ${modal ? "open" : "close"}`}> */}
        <div id="studentModal" className={`addStudentModal ${modal}`}>
            <div className="addStudentModalContent">
                <div className="form-container">
                <div className="headers">
                    <button className="closeBtn" onClick={handleClose}>X</button>
                    <h1>Student Subject</h1>
                </div>
                    <div>
                        <form onSubmit={handleSubmit} className='studentSubjectForm' autoComplete='off'>
                            <div className="studentName">
                                <label htmlFor="studentname">Student Name:</label>
                                    <select 
                                        type="text"
                                        id="studentname"
                                        onChange={handleChange}
                                        onBlur={handleBlur}
                                        value={values.studentname}
                                    >
                                        <option defaultValue>Default</option>
                                        {students.map((students) => (
                                            <option key={students.studentid} value={students.studentid}>
                                                {students.studentname}
                                            </option>
                                        ))}
                                    </select>
                            </div>
                            <div className="subjectName">
                                <label htmlFor="subjectname">Student Subject:</label>
                                <select 
                                    type="text"
                                    id="subjectname"
                                    onChange={handleChange}
                                    onBlur={handleBlur}
                                    value={values.subjectname}
                                    multiple
                                >
                                    {subjects.map((subject) => (
                                        <option key={subject.subjectid} value={subject.subjectid}>
                                            {subject.subjectname}
                                        </option>
                                    ))}
                                </select>
                            </div>
                            <div className="formButton">
                                <button type="submit" onClick={handleSubmit}>Submit</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </>
  )
}

export default AddStudentModal
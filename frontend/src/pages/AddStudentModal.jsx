import { useEffect, useState } from 'react';
import axios from 'axios';
import { useFormik } from 'formik';


const AddStudentModal = () => {

    const [students, setStudents] = useState([]);
    const [subjects, setSubjects] = useState([]);
    // const [subjectList, setSubjectList] = useState([]);
    // const [studentSubject, setStudentSubject] = useState([]);
    // const [subject, setSubject] = useState("");
  
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
  
    // const handleChange = (event) => {
    //   axios
    //     .get(`https://localhost:7139/api/StudentSubject/${event.target.value}`)
    //     .then((response) => {
    //       setStudent((data) => {
    //         return response.data;
    //       });
    //     });
    // };
  
    // useEffect(() => {
    //   student.map((std) => {
    //     setSubjects((prev) => [...prev, std.subjectid]);
    //   })
    // }, [student]);
  
  
    // useEffect(() => {
    //   for (var i = 0; i < subjects.length; i++)
    //   {
    //     subjectList.map((subject) => {
    //       if (subject.subjectid === subjects[i])
    //       {
    //         setStudentSubject((prev) => [...prev, subject.subjectname]);
    //       }
    //     })
    //   }
  
    // }, [subjects])

  return (
    <>
        <div id="studentModal" className="addStudentModal open">
            <div className="addStudentModalContent">
                <div className="form-container">
                    <h1>Student Subject</h1>
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
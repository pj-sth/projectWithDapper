import Navbar from './component/Navbar/Navbar';
import AddStudentModal from './pages/AddStudent/AddStudentModal';
import Form from './pages/Form/Form';

const App = () => {
  
  return (
    <>
      <Navbar />
      <div className='container'>
        <Form />
      </div>
    </>
  )
}
  

export default App
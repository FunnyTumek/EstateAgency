import './App.css';
import { Routes, Route } from 'react-router-dom';
import Layout from './components/layout';
import EditEstate from './components/editEstate';
import EstateList from './components/estateList';
import CreateEstate from './components/createEstate';
import Estate from './components/estate';

function App() {
  return (
    <>
      <Routes>
        <Route path='/' element={<Layout />}>
          <Route index element={<EstateList url={'/estates'} />} />
          <Route path='/create' element={<CreateEstate />} />
          <Route path='/edit' element={<EditEstate />} />
          <Route path='/show' element={<Estate />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;

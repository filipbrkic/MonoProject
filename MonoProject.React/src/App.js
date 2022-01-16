import NewVehicleMake from './components/NewVehicleMake';
import { inject, observer } from 'mobx-react';
import GetAllVehicleMakeList from './components/GetAllVehicleMakeList';

function App() {

  return (
    <div>
      <NewVehicleMake />
      <GetAllVehicleMakeList />
    </div>
  );
}

export default inject("rootStore")(observer(App));

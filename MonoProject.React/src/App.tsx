import NewVehicleMake from './components/NewVehicleMake';
import { inject, observer } from 'mobx-react';
import GetAllVehicleMakeList from './components/GetAllVehicleMake';
import { rootStore } from './stores/RootStore';


function App() {

  return (
    <div>
      <NewVehicleMake rootStore={rootStore} />
      <GetAllVehicleMakeList />
    </div>
  );
}

export default inject("rootStore")(observer(App));

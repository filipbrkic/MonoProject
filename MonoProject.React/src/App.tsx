import NewVehicleMake from './components/NewVehicleMake';
import { inject, observer } from 'mobx-react';
import GetAllVehicleMake from './components/GetAllVehicleMake';
import GetAllVehicleOwner from "./components/GetAllVehicleOwner";
import { rootStore } from './stores/RootStore';


function App() {

  return (
    <div>
      <NewVehicleMake rootStore={rootStore} />
      <GetAllVehicleMake />
      <GetAllVehicleOwner />
    </div>
  );
}

export default inject("rootStore")(observer(App));

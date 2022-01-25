import NewVehicleMake from './components/NewVehicleMake';
import { inject, observer } from 'mobx-react';
import GetAllVehicleMake from './components/GetAllVehicleMake';
import GetAllVehicleOwner from "./components/GetAllVehicleOwner";
import { rootStore } from './stores/RootStore';
import { Route, Switch } from "react-router-dom"

import MainNavigation from "./layouts/MainNavigation"
import NotFound from "./pages/NotFound"
import Home from "./pages/Home"


function App() {

  return (
    <div>
      <MainNavigation />
      <main>
        <Switch>
          <Route path="/" exact>
            <Home />
          </Route>
          <Route path="/new-vehicle-make">
            <NewVehicleMake rootStore={rootStore} />
            <GetAllVehicleMake />
          </Route>
          <Route path="/vehicle-owner">
            <GetAllVehicleOwner />
          </Route>
          <Route path="*">
            <NotFound />
          </Route>
        </Switch>
      </main>
    </div>
  );
}

export default inject("rootStore")(observer(App));

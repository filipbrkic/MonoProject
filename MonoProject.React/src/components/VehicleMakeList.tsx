import { autorun, observable } from "mobx";
import { inject, observer } from "mobx-react";
import { Key, ReactChild, ReactFragment, ReactPortal, useEffect, useState } from "react";
import VehicleMake from "./VehicleMake"

const VehicleMakeList = ({ rootStore }: any) => {

    useEffect(() => autorun(() => {
        rootStore.vehicleMakeListViewStore?.getAllVehicleMakeAsync();
    }), [])

    const list = observable(rootStore.vehicleMakeListViewStore.data).map((make: { id: Key | null | number; name: boolean | ReactChild | ReactFragment | ReactPortal | null | string; abrv: boolean | ReactChild | ReactFragment | ReactPortal | null | string; }) =>
        <VehicleMake key={make.id} make={make} />
    )

    return (
        <tbody>
            {list}
        </tbody>
    );
};

export default inject("rootStore")(observer(VehicleMakeList));
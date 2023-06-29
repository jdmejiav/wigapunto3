import './ExploreContainer.css';
import React, { useState, useEffect } from 'react';
import { IonItem, IonLabel, IonList, } from '@ionic/react';
import { useHistory } from 'react-router-dom';
interface ContainerProps { }

const UserListComponenet: React.FC<ContainerProps> = () => {

    const [clientList, setClientList] = useState<Array<any>>([])
    const history = useHistory();
    const getClientList = async (): Promise<void> => {
        const response = await fetch("https://localhost:7192/cliente/all", {
            method: 'GET',
            redirect: 'follow'
        })
            .then(response => response.json())
            .then(result => result)
            .catch(error => console.log('error', error));
        setClientList(response)


    }



    useEffect(() => {
        getClientList()
    }, [])


    return (
        <IonList>
            {
                clientList.map((val: { id: number, nombre: string }) => {
                    return <IonItem detail={true} button onClick={() => {
                        history.push(`/facturas/${val["id"]}`)
                    }}>
                        <IonLabel>
                            {
                                val["nombre"]
                            }
                        </IonLabel>

                    </IonItem>
                })
            }
        </IonList>
    );
};

export default UserListComponenet;

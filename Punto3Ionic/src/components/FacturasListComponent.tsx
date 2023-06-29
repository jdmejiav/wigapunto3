import './ExploreContainer.css';
import React, { useState, useEffect } from 'react';
import { IonItem, IonLabel, IonList, IonCol, IonGrid, IonRow } from '@ionic/react';
import { useParams } from 'react-router';
import moment from 'moment'
interface ContainerProps { }


type RouteParams = {
    id: string;
    category: string;
};
const FacturasListComponenet: React.FC<ContainerProps> = () => {

    const params = useParams<RouteParams>();
    const { id } = params;

    const [details, setDetails] = useState<any>({})
    const [facturasList, setFacturasList] = useState<Array<any>>([])

    const getFacturasList = async (): Promise<void> => {
        const response = await fetch(`https://localhost:7192/factura/user/${id}`, {
            method: 'GET',
            redirect: 'follow'
        })
            .then(response => response.json())
            .then(result => result)
            .catch(error => console.log('error', error));
        setFacturasList(response)
    }

    useEffect(() => {
        getFacturasList()
    }, [])


    return (
        <IonList>
            {
                facturasList.map((val: { numero: number, fecha: string, idCliente: number }) => {
                    return <IonItem detail={true} button onClick={async () => {
                        console.log(details[val["numero"]] !== undefined && details[val["numero"]]?.length !== 0, details[val["numero"]])
                        if (details[val["numero"]] !== undefined) {
                            if (details[val["numero"]]?.length !== 0) {
                                let temp = details
                                temp[val["numero"]] = undefined
                                setDetails({})
                            }
                        } else {
                            const productosFactura = await fetch(`https://localhost:7192/detalle/${val["numero"]}`, {
                                method: 'GET',
                            })
                                .then(response => response.json())
                                .then(result => result)
                                .catch(error => console.log('error', error));
                            let temp: any = {}
                            temp[val["numero"]] = productosFactura
                            setDetails(temp)
                        }
                    }}>
                        <IonGrid>
                            <IonLabel>
                                Factura {moment(val["fecha"]).format("LL")}
                            </IonLabel>
                            {
                                (details[val["numero"]] !== undefined) ?
                                    <IonGrid>
                                        <IonRow >
                                            <IonCol style={{backgroundColor: "#135d54", color:"#fff", border: "solid 1px #fff"}}>Producto</IonCol>
                                            <IonCol style={{backgroundColor: "#135d54", color:"#fff", border: "solid 1px #fff"}}>Cantidad</IonCol>
                                            <IonCol style={{backgroundColor: "#135d54", color:"#fff", border: "solid 1px #fff"}}>Precio</IonCol>
                                        </IonRow>
                                        {details[val["numero"]]?.map((item: any) => (
                                            <IonRow>
                                                <IonCol>{item["idProducto"]["nombre"]}</IonCol>
                                                <IonCol>{item["cantidad"]}</IonCol>
                                                <IonCol>{item["idProducto"]["precio"]}</IonCol>
                                            </IonRow>
                                        ))}
                                        <div style={{ marginLeft: "auto" }}>
                                            Total {details[val["numero"]]?.map((item: any) => (item["idProducto"]["precio"])).reduce((partialSum: number, a: number) => partialSum + a, 0)}
                                        </div>
                                    </IonGrid>
                                    : undefined
                            }
                        </IonGrid>
                    </IonItem>
                })
            }
        </IonList>
    );
};

export default FacturasListComponenet;

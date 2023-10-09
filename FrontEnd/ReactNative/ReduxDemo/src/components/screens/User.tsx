import React,{useState, useEffect} from 'react';
import {
  StyleSheet,
  Text,
  View,
  Button
} from 'react-native';
import { useDispatch } from 'react-redux';
import { addToCart, removeToCart } from '../redux/action';
import { useSelector } from 'react-redux';

const User = (props: any) => {
  const item = props.item;
  const cartData = useSelector((state: any)=>state.reducer);
  const [isAdded, setIsAdded]  = useState(false);
  const dispath = useDispatch();



  const handleAddToCart = (i: any) => {
    dispath(addToCart(i))
  }

  const handleRemoveToCart = (i: any) => {
    dispath(removeToCart(i))
    setIsAdded(false)
  }


  useEffect(() => {
    if( cartData && cartData.length){
      cartData.forEach((element:any) => {
        if(element.firstName == item.firstName && element.lastName == item.lastName){
          setIsAdded(true)
        }
      });
    }
  })

  return (
    <View style={styles.contentView} key={item.id}>
      <Text style={styles.center}>{item.firstName}</Text>
      <Text style={styles.center}>{item.lastName}</Text>
      <Text style={styles.center}>{item.city}</Text>
      <Text style={styles.center}>{item.country}</Text>
      <Text style={styles.center}>{item.GDP}</Text>
      {
        isAdded ? 
        <Button title="Remove" onPress={()=> handleRemoveToCart(item)}></Button>:
        <Button title="Add" onPress={()=> handleAddToCart(item)}></Button>
      
      }
  </View>
  )
}

const styles = StyleSheet.create({
  contentView:{
    marginBottom: 20
  }
  ,
  center: {
    textAlign: 'center'
  },

});

export default User;

import React, { useState, useEffect } from 'react';
import {
  StyleSheet,
  Text,
  View,
} from 'react-native';
import { useSelector } from 'react-redux';

const Header = () => {

  const cartData = useSelector((state: any) => state.reducer)
  const [cartItems, setCarItems] = useState(0);

  useEffect(() => {
    setCarItems(cartData.length);
  }, [cartData])


  return (
    <View style={styles.container}>
      <Text style={{ fontSize: 30, textAlign: 'right' }}> {cartItems} User</Text>
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#ccc'
  }
});

export default Header;

import React, { useState, useEffect } from 'react';
import {
  StyleSheet,
  Text,
  View,
} from 'react-native';
import { useSelector, useDispatch } from 'react-redux';
import { getUserList } from '../redux/action';

const UserList = () => {

  const dispatch = useDispatch();
  const users = useSelector((state: any) => state.reducer)

  useEffect(() => {
    dispatch(getUserList());
  }, [])

  console.warn("data:",users)

  return (
    <View style={styles.container}>
      {/* {
        
        // userList.length ?
        userList.map((item: any) => (<Text> {item.title}</Text>))
      } */}
    </View>
  )
}

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#ccc'
  }
});

export default UserList;

import React, { useState, useRef } from 'react';
import {
  Image,
  StyleSheet,
  Text,
  TextInput,
  View,
  Pressable,
  TouchableOpacity,
  Alert,

} from 'react-native';

import LinearGradient from 'react-native-linear-gradient';

const App = () => {
  const [getPassword, setPassword] = useState('');
  const [getEmail, setEmail] = useState('');
  const [isSecure, setIsSecure] = useState(true);

  const handleIsSecure = () => {
    setIsSecure(!isSecure)
  }

  const handleLogin = () => {
    Alert.alert('Thông báo', `Tài khoản của bạn là: \n Email:  ${getEmail} \n Password: ${getPassword}`, [
      { text: 'Cancel', onPress: () => console.log('Hủy'), style: 'cancel' },
      { text: 'OK', onPress: () => console.log('Đăng nhập thành công.') },
    ]);
  }

  return (
    <View style={styles.container}>
      <Image
        style={styles.logoCustom}
        source={require('./assets/image/vecteezy_karaoke-music-mic.jpg')}
      />

      <Text style={styles.header}>Sign In</Text>

      <Text style={styles.header}>To continue</Text>

      <View style={styles.formInput}>
        <TextInput style={styles.email} onChangeText={(e) => setEmail(e)} placeholder='info@petermocanu.com' />

        <TextInput style={styles.password} onChangeText={(e) => setPassword(e)} secureTextEntry={isSecure} placeholder='Enter your password' />

        <TouchableOpacity onPress={handleIsSecure} style={styles.eyePosition}>
          <Image
            style={styles.iconEye}
            source={require('./assets/image/eyeball.png')}
          />
        </TouchableOpacity>
      </View>

      <LinearGradient start={{ x: 0, y: 1 }} end={{ x: 1, y: 0 }} colors={['#3494E6', '#EC6EAD']} style={{ borderRadius: 20, marginBottom: 15 }}>
        <TouchableOpacity onPress={handleLogin} style={styles.btnLogin}>
          <Text style={styles.text}>Sign In</Text>
        </TouchableOpacity>
      </LinearGradient>

      <Text style={styles.lostPassWord}>Lost password?</Text>

      <View style={styles.loginExternal}>
        <LinearGradient
          start={{ x: 0, y: 1 }} end={{ x: 1, y: 0 }} colors={['#3494E6', '#EC6EAD']}
          style={styles.btnLoginExternal}>
          <TouchableOpacity style={styles.layoutBtnLoginExternal}>
            <Image
              style={{ width: 15, height: 15 }}
              source={require('./assets/image/logo-google.png')}
            />
            <Text style={styles.textExternal}>Google</Text>
          </TouchableOpacity>
        </LinearGradient>

        <LinearGradient
          start={{ x: 0, y: 1 }} end={{ x: 1, y: 0 }} colors={['#3494E6', '#EC6EAD']}
          style={styles.btnLoginExternal}>
          <TouchableOpacity style={styles.layoutBtnLoginExternal}>
            <Image
              style={{ width: 15, height: 15 }}
              source={require('./assets/image/logo-facebook.png')}
            />
            <Text style={styles.textExternal}>Facebook</Text>
          </TouchableOpacity>
        </LinearGradient>

      </View>

      <View style={styles.footer}>
        <Text style={styles.br}></Text>

        <View style={{ flexDirection: 'row', justifyContent: 'center' }}>
          <Text>Don't have an account?</Text>

          <Text style={{ fontWeight: '700' }}> Register</Text>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#ffffff',
  },

  layout: {
    flexDirection: 'column',
  },

  logoCustom: {
    width: 120,
    height: 120,
    resizeMode: 'center',
    alignSelf: 'center'
  },

  header: {
    fontSize: 18,
    fontWeight: '500',
    textTransform: "uppercase",
    textAlign: 'center'
  },

  formInput: {
    alignItems: 'center',
    marginTop: 30,
    width: '80%'
  },

  email: {
    backgroundColor: '#EEEEEE',
    width: '100%',
    paddingBottom: 10,
    paddingTop: 10,
    paddingLeft: 20,
    paddingRight: 20,
    marginBottom: 20,
    borderRadius: 20,
    color: 'black'
  },

  password: {
    position: 'relative',
    backgroundColor: '#EEEEEE',
    width: '100%',
    paddingBottom: 10,
    paddingTop: 10,
    paddingLeft: 20,
    paddingRight: 20,
    marginBottom: 20,
    borderRadius: 20,
    color: 'black'
  },

  btnLogin: {
    width: 150,
    paddingVertical: 12,
    paddingHorizontal: 12,
  },

  btnLogin1: {
    width: 150,
    height: 40,
    paddingVertical: 12,
    paddingHorizontal: 12,
  },

  text: {
    textAlign: 'center',
    fontSize: 16,
    lineHeight: 18,
    fontWeight: '500',
    letterSpacing: 0.25,
    color: 'white',
  },

  lostPassWord: {
    textAlign: 'center',
    fontSize: 14,
    lineHeight: 18,
    fontWeight: '400',
    letterSpacing: 0.25,
    color: 'black',
    marginBottom: 30
  },

  loginExternal: {
    width: '80%',
    marginTop: 30,
    flexDirection: 'row',
    flexWrap: 'wrap',
    justifyContent: 'space-between',
  },

  btnLoginExternal: {
    height: 44,
    width: '40%',
    padding: 4, 
    alignItems: 'center',
    borderRadius: 20
  },

  layoutBtnLoginExternal: {
    backgroundColor: 'white',
    padding: 10,
    borderRadius: 20,
    flexDirection: 'row',
    alignItems: 'center', width: '100%'
  },

  textExternal: {
    marginLeft: 10,
    textAlign: 'center',
    fontSize: 14,
    lineHeight: 18,
    fontWeight: '400',
    letterSpacing: 0.25,
  },

  footer: {
    marginTop: 30,
    width: '80%',
  },

  br: {
    width: '25%',
    borderTopWidth: 2,
    alignSelf: 'center'
  },

  eyePosition: {
    position: 'absolute',
    top: 80,
    right: 13
  },

  iconEye: {
    width: 25,
    height: 25,

  },
});

export default App;

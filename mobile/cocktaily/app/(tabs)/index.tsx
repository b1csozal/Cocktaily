import { SafeAreaView } from "react-native-safe-area-context";
import { Text, StyleSheet } from "react-native";

const TabsHome = () => {
  return (
    <SafeAreaView style={styles.container}>
        <Text>Tabs Home</Text>
    </SafeAreaView>
  );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
});

export default TabsHome;
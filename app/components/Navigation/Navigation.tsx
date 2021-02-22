import Calendar from '../../public/icons/sidebar/calendar.svg'
import Dashboard from '../../public/icons/sidebar/Dashboard.svg'
import Subjects from '../../public/icons/sidebar/Subjects.svg'
import { Box, Button, Flex, Link, List } from '@chakra-ui/react'
import NextLink from 'next/link'
import { useRouter } from 'next/router'
import React from 'react'
import Zakladka from '../../public/icons/zakladka.svg'

interface Data {
  icon: JSX.Element
  href: string
}

export const Navigation = () => {
  const { push } = useRouter()
  const navigationData: Record<string, Data> = {
    Dashboard: {
      icon: <Dashboard />,
      href: '/app',
    },
    Kalendarz: {
      icon: <Calendar />,
      href: '/calendar',
    },
    Przedmioty: {
      icon: <Subjects />,
      href: '/subjects',
    },
    Projekty: {
      icon: <Subjects />,
      href: '/projects',
    },
  }

  const renderNavigation = () => (
    <List>
      {Object.keys(navigationData).map((key) => (
        <Box
          key={key}
          marginLeft={5}
          marginRight={5}
          marginBottom={5}
          as={Flex}
          flexDir="row"
          alignItems="center"
          color="white"
          fontSize="28px"
        >
          {navigationData[key].icon}
          <Link as={NextLink} href={navigationData[key].href}>
            {key}
          </Link>
        </Box>
      ))}
    </List>
  )

  return (
    <Flex
      justifyContent="space-between"
      alignItems="center"
      pt={200}
      flexDir="column"
      h="100vh"
      backgroundColor="#2B2E61"
      w="300px"
    >
      {/* <Zakladka /> */}
      {renderNavigation()}
      <Button
        width="100%"
        height="55px"
        fontSize="26px"
        onClick={() => {
          localStorage.setItem('token', '')
          push('/login')
        }}
      >
        Wyloguj
      </Button>
    </Flex>
  )
}

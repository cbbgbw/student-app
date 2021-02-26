import Calendar from '../../public/icons/sidebar/calendar.svg'
import Dashboard from '../../public/icons/sidebar/dashboard.svg'
import Subjects from '../../public/icons/sidebar/subjects.svg'
import { Box, Button, Flex, Link, List } from '@chakra-ui/react'
import NextLink from 'next/link'
import { useRouter } from 'next/router'
import React from 'react'
import Zakladka from '../../public/icons/zakladka.svg'
import Image from 'next/image'

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
      pt="80px"
      flexDir="column"
      h="100vh"
      backgroundColor="#2B2E61"
      w="300px"
    >
      <Box position="absolute" top={-5} left={5}>
        <Zakladka />
      </Box>
      <Box width="250px" height="250px">
        <Image
          src="/icons/sidebar/logo.png"
          alt="logo"
          width="250px"
          height="250px"
        />
      </Box>
      <Flex flexDir="column" height="100%" justifyContent="space-between">
        {renderNavigation()}
        <Button
          width="100%"
          height="55px"
          fontSize="26px"
          onClick={async () => {
            localStorage.setItem('token', '')
            await push('/login')
          }}
        >
          Wyloguj
        </Button>
      </Flex>
    </Flex>
  )
}

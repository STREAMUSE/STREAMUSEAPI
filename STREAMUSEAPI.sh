#!/bin/sh

if [[ $current_branch = $protected_branch ]] ; then
    echo -e "${YELLOW}Running pre push to master check...${NC}"
    
    echo -e "${YELLOW}Trying to build tests project...${NC}"
    
    DOTNET_CLI_TELEMETRY_OPTOUT=1
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
    
    dotnet build
    
    rc=$?
    if [[ $rc != 0 ]] ; then
        echo -e "${RED}Failed to build the project, please fix this and push again${NC}"
        echo ""
        exit $rc
    fi
    
    cd STREAMUSEAPITests
    
    echo -e "${YELLOW}Running unit tests...${NC}"
    echo ""
    
    dotnet test
    
    rc=$?
    if [[ $rc != 0 ]] ; then
        echo -e "${RED}Unit tests failed, please fix and push again${NC}"
        echo ""
        exit $rc
    fi
    
    echo -e "${GREEN}Pre push check passed!${NC}"
    echo ""
fi

exit 0